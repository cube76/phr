// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var vapidPublicKey = "BIpSeI-eSgRnXTLbKnRwDn7IiQKwjzGoX7rZ7XV4OAg5xZJyjB8cyyZjEyb_dVZ66Lvz-baaS6JNFNWFE9IrZ6I";
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
		// console.log('User  subscribed:', subscription);
		sendSubscriptionToServer(subscription);
	} catch (error) {
		console.error('Failed to subscribe user:', error);
	}
}

function sendSubscriptionToServer(subscription) {
	var userId = "1232"
	fetch('https://a090-202-43-95-42.ngrok-free.app/subscribe', { //example post notification backend url
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

$(document).ready(function() {
    $('.datePicker').datepicker({
        format: 'dd-M-yyyy', 
        autoclose: true 
    }); 

    $('.datePicker').on('click', function() {
        $(this).datepicker('show');
    });
});