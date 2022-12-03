import { deleteAlbumById, getAlbumById } from '../api/data.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';


const detailsTemplate = (album, isOwner, onDelete, isGuest, onLike) =>html`<section id="details">
    <div id="details-wrapper">
        <p id="details-title">Album Details</p>
        <div id="img-wrapper">
            <img src=${album.imageUrl} alt="example1" />
        </div>
        <div id="info-wrapper">
            <p><strong>Band:</strong><span id="details-singer">${album.singer}</span></p>
            <p>
                <strong>Album name:</strong><span id="details-album">${album.album}</span>
            </p>
            <p><strong>Release date:</strong><span id="details-release">${album.release}</span></p>
            <p><strong>Label:</strong><span id="details-label">${album.label}</span></p>
            <p><strong>Sales:</strong><span id="details-sales">${album.sales}</span></p>
        </div>
        <div id="likes">Likes: <span id="likes-count">0</span></div>
        <div id="action-buttons">
            ${ 

               isGuest? isOwner ? html`<a href="/edit/${album._id}" id="edit-btn">Edit</a>
            <a @click=${onDelete} id="delete-btn">Delete</a>` : html`<a href="" id="like-btn">Like</a>` : null
            }
        </div>
    </div>
</section>`;



export async function detailsPage(ctx) {

    const album = await getAlbumById(ctx.params.id);


    const userData = getUserData();
    const isOwner = userData && album._ownerId == userData.id;

    let isGuest = true;
    
    if(userData == null){
        isGuest = false;
    }

    ctx.render(detailsTemplate(album, isOwner, onDelete, isGuest));

    async function onDelete() {
        const choice = confirm('Are you sure you want to delete this meme?');

        if (choice) {
            await deleteAlbumById(ctx.params.id);
            ctx.page.redirect('/dashboard');
        }
    }
}