import { register } from '../api/data.js';
import {html} from '../lib.js';

const registerTemplate = (onSubmit) =>html`<section id="register">
<div class="form">
  <h2>Register</h2>
  <form @submit=${onSubmit} class="login-form">
    <input type="text" name="email" id="register-email" placeholder="email" />
    <input type="password" name="password" id="register-password" placeholder="password" />
    <input type="password" name="re-password" id="repeat-password" placeholder="repeat password" />
    <button type="submit">register</button>
    <p class="message">Already registered? <a href="/login">Login</a></p>
  </form>
</div>
</section>
`;

export function registerPage(ctx){

    ctx.render(registerTemplate(onSubmit));

    async function onSubmit(event){
        event.preventDefault();
        const formData = new FormData(event.target);

        //const username = formData.get('username');
        const email = formData.get('email');
        const password = formData.get('password');
        const repeatPass = formData.get('re-password');
      

        if(email =='' || password == '' || repeatPass == ''){
            return alert('All fields are required!');
        }

        if(password !== repeatPass){
            return alert('Passwords don\'t match');
        }

        await register(email, password);
        ctx.updateUserNav();
        ctx.page.redirect('/dashboard');

    }
}