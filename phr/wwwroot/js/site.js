// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

self.addEventListener('push', function (event) {
    const data = event.data.json();
    const options = {
        body: data ? data.body : 'No payload',
        icon: '/images/logo_iem.png', 
        badge: '/images/logo_iem.png' 
    };

    event.waitUntil(
        self.registration.showNotification(data.title, options)
    );
});