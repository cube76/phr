self.addEventListener('push', function (event) {
    const data = event.data.json();
    const options = {
        body: data ? data.body : 'No payload',
        icon: '/favicon.ico', 
        badge: '/favicon.ico' 
    };

    event.waitUntil(
        self.registration.showNotification(data.title, options)
    );
});