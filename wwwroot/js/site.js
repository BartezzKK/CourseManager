// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const scrollToTopBtn = document.getElementById('scrollToTopBtn');
const rootElement = document.documentElement;


scrollToTopBtn.addEventListener('click', scrollToTop);
function scrollToTop() {
    rootElement.scrollTo({
        top: 0,
        behavior: 'smooth',
    });
}

function handleScroll() {
    const scrollTotal = rootElement.scrollHeight - rootElement.clientHeight;

    if (rootElement.scrollTop / scrollTotal < 0.2) {
        scrollToTopBtn.style.transform = 'translateX(100px)';
    } else {
        scrollToTopBtn.style.transform = 'translateX(0)';
    }
}
document.addEventListener('scroll', handleScroll);


