// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Update cart count in navigation
function updateCartCount() {
    fetch('/Cart/Index')
        .then(response => response.text())
        .then(html => {
            const parser = new DOMParser();
            const doc = parser.parseFromString(html, 'text/html');
            const cartItems = doc.querySelectorAll('.cart-item');
            const count = cartItems.length;
            
            const cartLink = document.querySelector('a[href="/Cart"]');
            if (cartLink) {
                cartLink.textContent = `Cart (${count})`;
            }
        })
        .catch(error => console.error('Error updating cart count:', error));
}

// Call updateCartCount on page load
document.addEventListener('DOMContentLoaded', function() {
    updateCartCount();
});

// Smooth scroll for anchor links
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();
        const target = document.querySelector(this.getAttribute('href'));
        if (target) {
            target.scrollIntoView({
                behavior: 'smooth'
            });
        }
    });
});
