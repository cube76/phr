// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let vapidPublicKey;

fetch("http://localhost:4000/")  // your API endpoint
    .then(response => {
        if (!response.ok) {
            throw new Error("Network response was not ok");
        }
        return response.json(); // parse response as JSON
    })
    .then(data => {
        vapidPublicKey = data.publicKey; // access the "publicKey" field
        console.log("Fetched VAPID public key:", vapidPublicKey);
    })
    .catch(error => {
        console.error("Error fetching VAPID key:", error);
    });

async function initServiceWorker() {
    if ('serviceWorker' in navigator) {
        const swRegistration = await navigator.serviceWorker.register('/js/service-worker.js');

        const subscription = await swRegistration.pushManager.getSubscription();

        if (subscription) {
            // console.log('User  is already subscribed:', subscription);
            sendSubscriptionToServer(subscription);
        } else {
            subscribeUser(swRegistration);
        }
    } else {
        console.warn('Service worker is not supported');
    }
}

async function subscribeUser(swRegistration) {
    try {
        const subscription = await swRegistration.pushManager.subscribe({
            userVisibleOnly: true,
            applicationServerKey: urlBase64ToUint8Array(vapidPublicKey)
        });
         console.log('User  subscribed:', subscription);
        sendSubscriptionToServer(subscription);
    } catch (error) {
        console.error('Failed to subscribe user:', error);
    }
}

function sendSubscriptionToServer(subscription) {
    var userId = "1232"
    fetch('http://localhost:4000/subscribe', {
        method: 'POST',
        body: JSON.stringify({ userId: userId, subscription: subscription }),
        headers: {
            'Content-Type': 'application/json'
        }
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('Failed to send subscription to server');
        }
        return response.json();
    })
    .then(data => {
        console.log('Subscription sent to server:', data);
    })
    .catch(error => {
        console.error('Error sending subscription to server:', error);
    });
};

function urlBase64ToUint8Array(base64String) {
    const padding = '='.repeat((4 - base64String.length % 4) % 4);
    const base64 = (base64String + padding).replace(/-/g, '+').replace(/_/g, '/');
    const rawData = window.atob(base64);
    return new Uint8Array([...rawData].map(char => char.charCodeAt(0)));
};

window.addEventListener('load', () => {
    initServiceWorker();
});

$(document).ready(function () {
    $('.datePicker').datepicker({
        format: 'dd-M-yyyy',
        autoclose: true
    });

    $('.datePicker').on('click', function () {
        $(this).datepicker('show');
    });
});

const fileInput = document.getElementById('file-upload');
const listContainer = document.getElementById('attachment-list');
const alertBox = document.getElementById('upload-alert');
let currentFiles = [];

fileInput.addEventListener('change', () => {
    const newFiles = Array.from(fileInput.files);
    const totalFiles = currentFiles.length + newFiles.length;

    if (totalFiles > 4) {
        alertBox.textContent = 'Maksimal 4 files.';
        alertBox.classList.remove('d-none');
        fileInput.value = ''; // Clear the selection
        return;
    }

    alertBox.classList.add('d-none'); // Hide alert if no issue
    currentFiles = currentFiles.concat(newFiles);
    renderFileList();
    fileInput.value = ''; // Reset input so same file can be re-selected if needed
});

function renderFileList() {
    listContainer.innerHTML = '';
    currentFiles.forEach((file, index) => {
        const listItem = document.createElement('li');
        listItem.className = 'list-group-item d-flex justify-content-between align-items-center';
        listItem.innerHTML = `
			${file.name}
			<button type="button" class="btn-close" aria-label="Remove" onclick="removeFile(${index})"></button>
		  `;
        listContainer.appendChild(listItem);
    });
}

function removeFile(index) {
    currentFiles.splice(index, 1);
    renderFileList();
}