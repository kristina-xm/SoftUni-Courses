import { createAlbum } from '../api/data.js';
import { html } from '../lib.js';


const createTemplate = (onSubmit) =>html`<section id="create">
<div class="form">
  <h2>Add Album</h2>
  <form @submit=${onSubmit} class="create-form">
    <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" />
    <input type="text" name="album" id="album-album" placeholder="Album" />
    <input type="text" name="imageUrl" id="album-img" placeholder="Image url" />
    <input type="text" name="release" id="album-release" placeholder="Release date" />
    <input type="text" name="label" id="album-label" placeholder="Label" />
    <input type="text" name="sales" id="album-sales" placeholder="Sales" />

    <button type="submit">post</button>
  </form>
</div>
</section>`;

export function createPage(ctx) {

    ctx.render(createTemplate(onSubmit));


    async function onSubmit(event){
        event.preventDefault();
        const formData = new FormData(event.target);

        const singer = formData.get('singer').trim();
        const album = formData.get('album').trim();
        const imageUrl = formData.get('imageUrl').trim();
        const release = formData.get('release').trim();
        const label = formData.get('label').trim();
        const sales = formData.get('sales').trim();
       

        if(singer =='' || album == '' || imageUrl =='' || release == '' || label == '' || sales == ''){
            return alert('All fields are required');
        }
        await createAlbum({
            singer,
            album, 
            imageUrl, 
            release, 
            label, 
            sales
          });

        ctx.page.redirect('/dashboard');
    }
}