import {page, render} from './lib.js';


/* debug */
import * as api from './api/data.js';
window.api = api;

page('/', homePage);
page('/memes', catalogPage);

page.start();