const glob = require('glob-all');
const PurgecssPlugin = require('purgecss-webpack-plugin');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const PurifyCSSPlugin = require('purifycss-webpack');
const path = require("path");

module.exports = {
    entry: {
        site: './wwwroot/js/site.js',
        bootstrap_js: './wwwroot/js/bootstrap_js.js',
        validation: './wwwroot/js/validation.js',
        index: './wwwroot/js/index.js'
    },
    output: {
        filename: '[name].entry.js',
        path: path.join(__dirname, 'wwwroot/dist')
    },
    devtool: 'source-map',
    mode: 'development',
    module: {
        rules: [
            { test: /\.css$/, use: [{ loader: MiniCssExtractPlugin.loader }, "css-loader"] },
            { test: /\.eot(\?v=\d+\.\d+\.\d+)?$/, loader: "file-loader" },
            { test: /\.(woff|woff2)$/, loader: "url-loader?prefix=font/&limit=5000" },
            { test: /\.ttf(\?v=\d+\.\d+\.\d+)?$/, loader: "url-loader?limit=10000&mimetype=application/octet-stream" },
            { test: /\.svg(\?v=\d+\.\d+\.\d+)?$/, loader: "url-loader?limit=10000&mimetype=image/svg+xml" },
            {
                test: /\.(png|jpg|gif)$/i,
                use: [
                    {
                        loader: 'url-loader',
                        options: {
                            limit: 8192,
                            fallback: 'file-loader'
                        }
                    }
                ]
            }
        ]           
    },
    plugins: [
        new MiniCssExtractPlugin({ filename: "[name].css"}),
        new PurgecssPlugin({ paths: glob.sync('./Views/**/*.cshtml', { nodir: true }) }),
        new PurifyCSSPlugin({
            paths: glob.sync([
                path.join(__dirname, 'Views/**/*.cshtml'),
                path.join(__dirname, 'wwwroot/**/*.js')
            ]),
            minimize: true,
            purifyOptions: {
                whitelist: []
            }
        })
    ],
    node: {
        __dirname: false
    }
};