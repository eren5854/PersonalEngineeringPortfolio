// @ts-nocheck
const form = document.getElementById('loginForm');
const btn = document.getElementById('btn');
const pw = document.getElementById('pw');

const swalBase = {
    background: '#0a1630',
    color: '#e6f1ff',
    confirmButtonColor: '#1e90ff',
    confirmButtonText: 'Tamam'
};

document.getElementById('eye').addEventListener('click', e => {
    const show = pw.type === 'password';
    pw.type = show ? 'text' : 'password';
    e.currentTarget.textContent = show ? 'gizle' : 'göster';
});

form.addEventListener('submit', async e => {
    e.preventDefault();

    const emailOrUserName = form.emailOrUserName.value.trim();
    const password = form.password.value;

    if (!emailOrUserName || !password) {
        Swal.fire({ ...swalBase, icon: 'warning', title: 'Eksik Bilgi', text: 'Lütfen e-posta ve şifrenizi giriniz.' });
        return;
    }

    btn.disabled = true;
    btn.classList.add('loading');

    try {
        const res = await fetch('/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ emailOrUserName, password })
        });
        const data = await res.json().catch(() => ({}));

        if (res.ok) {
            await Swal.fire({
                ...swalBase,
                icon: 'success',
                title: 'Giriş başarılı',
                text: 'Yönlendiriliyorsunuz...',
                timer: 1000,
                showConfirmButton: false
            });
            window.location.href = data.redirectUrl || '/admin-panel';
            return;
        }

        Swal.fire({
            ...swalBase,
            icon: res.status === 400 ? 'warning' : 'error',
            title: res.status === 400 ? 'Eksik Bilgi' : 'Giriş Başarısız',
            text: data.message || 'Bir hata oluştu. Lütfen tekrar deneyiniz.'
        });
    } catch {
        Swal.fire({ ...swalBase, icon: 'error', title: 'Bağlantı Hatası', text: 'Sunucuya ulaşılamadı. Lütfen tekrar deneyiniz.' });
    } finally {
        btn.disabled = false;
        btn.classList.remove('loading');
    }
});