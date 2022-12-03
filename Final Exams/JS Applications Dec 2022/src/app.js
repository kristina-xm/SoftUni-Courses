import { logout } from './api/api.js';
import * as api from './api/data.js';
import { page, render } from './lib.js';
import { getUserData } from './util.js';
import { createPage } from './views/create.js';
import { dashboardPage } from './views/dashboard.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { homePage } from './views/home.js';
import { loginPage } from './views/login.js';
import { registerPage } from './views/register.js';

const root = document.querySelector('main');
document.getElementById('logoutBtn').addEventListener('click', onLogout);

window.api = api;

page(decorateContext);

page('/', homePage);
page('/dashboard', dashboardPage);
page('/login', loginPage);
page('/register', registerPage);
page('/create', createPage);
page('/edit/:id', editPage);
page('/details/:id', detailsPage);



updateUserNav()
page.start();

function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, root);
    ctx.updateUserNav = updateUserNav;

    next();

}

function onLogout() {
    logout();
    updateUserNav();
}

function updateUserNav() {
    const userData = getUserData();

    if (userData) {
        document.querySelector('.user').style.display = 'block';
        document.querySelector('.guest').style.display = 'none';
        // document.querySelector('.user span').textContent = `Welcome, ${userData.email}`;
    } else {

        document.querySelector('.user').style.display = 'none';
        document.querySelector('.guest').style.display = 'block';
    }
}