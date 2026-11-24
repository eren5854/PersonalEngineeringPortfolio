document.getElementById('logout').addEventListener('click', async () => {
    const res = await fetch('/logout', { method: 'POST' });
    const data = await res.json().catch(() => ({}));
    window.location.href = data.redirectUrl || '/login';
});