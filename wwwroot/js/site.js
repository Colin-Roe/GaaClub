import 'bootstrap/dist/css/bootstrap.css';

// Custom CSS imports
import '../css/site.css';
import logo from '../img/stuttgart_logo-512x512.png';

var logoImg = document.getElementById('logo');
logoImg.src = logo;
    
console.log('The \'site\' bundle has been loaded!');