import { editAlbum, getAlbumById } from '../api/data.js';
import { html } from '../lib.js';


const editTemplate = (album, onSubmit) =>html`<section id="edit">
<div class="form">
  <h2>Edit Album</h2>
  <form @submit=${onSubmit} class="edit-form">
    <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" .value=${album.singer}/>
    <input type="text" name="album" id="album-album" placeholder="Album" .value=${album.album}/>
    <input type="text" name="imageUrl" id="album-img" placeholder="Image url" .value=${album.imageUrl}/>
    <input type="text" name="release" id="album-release" placeholder="Release date" .value=${album.release}/>
    <input type="text" name="label" id="album-label" placeholder="Label" .value=${album.label}/>
    <input type="text" name="sales" id="album-sales" placeholder="Sales" .value=${album.sales}/>

    <button type="submit">post</button>
  </form>
</div>
</section>`;



export async function editPage(ctx) {

    const album = await getAlbumById(ctx.params.id);

    ctx.render(editTemplate(album, onSubmit));


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
        await editAlbum(ctx.params.id, {
            singer,
            album, 
            imageUrl, 
            release, 
            label, 
            sales
        });

        ctx.page.redirect(`/details/${ctx.params.id}`);

    }
}