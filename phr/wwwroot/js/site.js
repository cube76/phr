// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var vapidPublicKey = "BFxWi6h09Jl7QIhbSBNq-bxu-VPwbetszwvy8QHUn1F15U13Bbw_MFI1yz_UnYGJAy9T7iorpewAjprhYZ8_6bE";
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
    fetch('https://20.6.90.72:4001/subscribe', {
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