
const $ = s => document.querySelector(s), $$ = s => [...document.querySelectorAll(s)];
$('#yr').textContent = new Date().getFullYear();
/* menu close + active link */
$$('.menu a').forEach(a => a.onclick = () => $('.menu').classList.remove('open'));
const secs = $$('section');
/* typing */
const roles = ['Elektrik-Elektronik Mühendisi', 'Gömülü Sistem Geliştirici', 'Otomasyon Tasarımcısı']; let ri = 0, ci = 0, del = false;
(function t() {
    const w = roles[ri]; $('#type').textContent = w.slice(0, ci);
if (!del && ci == w.length) {del = true; return setTimeout(t, 1600) }
if (del && ci == 0) {del = false; ri = (ri + 1) % roles.length }
ci += del ? -1 : 1; setTimeout(t, del ? 35 : 80)
})();
/* wires */
const wires = $$('[data-w]');
function onScroll() {
    const y = scrollY, h = innerHeight;
    $('#top').classList.toggle('show', y > 500);
    let cur = secs[0]; secs.forEach(s => { if (s.offsetTop - 120 <= y) cur = s });
    $$('.menu a').forEach(a => a.classList.toggle('on', a.hash == '#' + cur.id));
    wires.forEach(w => {
    const r = w.getBoundingClientRect();
const p = Math.min(1, Math.max(0, (h * .75 - r.top) / r.height));
const fg = w.querySelector('.fg'); fg.style.strokeDashoffset = 1 - p;
let sp = w.querySelector('.spark');
if (!sp) {sp = document.createElement('div'); sp.className = 'spark'; for (let k = 0; k < 9; k++) { const i = document.createElement('i'); i.style.setProperty('--a', (k * 40 - 160 + Math.random() * 25) + 'deg'); i.style.setProperty('--d', (k * 67 % 600) + 'ms'); sp.appendChild(i) } w.appendChild(sp) }
const sv = w.querySelector('svg'), pt = fg.getPointAtLength(fg.getTotalLength() * p);
    sp.style.left = pt.x * sv.clientWidth / 44 + 'px'; sp.style.top = pt.y * sv.clientHeight / 400 + 'px'; sp.style.opacity = (p > 0.005 && p < 0.995) ? 1 : 0;
    w.querySelectorAll('.it').forEach((it, i, all) => it.classList.toggle('on', p > (i + .4) / all.length));
    });
}
addEventListener('scroll', onScroll, {passive: true }); onScroll();
$('#top').onclick = () => scrollTo({top: 0, behavior: 'smooth' });
/* oscilloscope */
const cats = [['CH1 · Donanım', ['Devre Tasarımı', 'PCB (KiCad)', 'Altium', 'Lehimleme', 'Ölçüm & Test', 'Sensörler']],
['CH2 · Yazılım', ['C / C++', 'Python', 'Embedded Linux', 'RTOS', 'Git', 'JavaScript']],
['CH3 · Güç', ['SMPS', 'Motor Sürücü', 'Inverter', 'Batarya Yönetimi', 'EMC', 'Simülasyon']],
['CH4 · Otomasyon', ['PLC', 'SCADA', 'Modbus', 'MQTT', 'Arduino', 'Raspberry Pi']]];
let cat = 0; const cv = $('#wave'), cx = cv.getContext('2d');
const kn = $('#knobs');
cats.forEach((c, i) => { const b = document.createElement('button'); b.className = 'knob'; b.innerHTML = 'CH' + (i + 1) + '<span>' + c[0].split('· ')[1] + '</span>'; b.onclick = () => setCat(i); kn.appendChild(b) });
function setCat(i) {
    cat = (i + cats.length) % cats.length;
    $$('.knob').forEach((k, j) => k.classList.toggle('on', j == cat));
$('#sk').innerHTML = '<div class="ch">' + cats[cat][0] + '</div>' + cats[cat][1].map((s, j) => '<span style="animation-delay:' + j * 70 + 'ms">' + s + '</span>').join('')
}
$('#prev').onclick = () => setCat(cat - 1); $('#next').onclick = () => setCat(cat + 1); setCat(0);
let ph = 0;
function draw() {
    const r = cv.getBoundingClientRect(), d = devicePixelRatio || 1;
if (cv.width != r.width * d) {cv.width = r.width * d; cv.height = r.height * d }
const W = cv.width, H = cv.height; cx.clearRect(0, 0, W, H); cx.lineWidth = 2 * d; cx.strokeStyle = '#00d4ff'; cx.shadowColor = '#00d4ff'; cx.shadowBlur = 10;
cx.beginPath(); const f = (cat + 1) * 2.2;
for (let x = 0; x <= W; x += 3) {
    const t = x / W * Math.PI * f + ph;
let v = cat == 0 ? Math.sin(t) : cat == 1 ? Math.sign(Math.sin(t)) * .8 : cat == 2 ? (Math.asin(Math.sin(t)) * 2 / Math.PI) : (Math.sin(t) + Math.sin(t * 3) / 3) * .8;
const y = H * .78 + v * H * .14; x ? cx.lineTo(x, y) : cx.moveTo(x, y)
    }
cx.stroke(); ph += .05; requestAnimationFrame(draw)
}
draw();
/* projects */
const P = [['Akıllı Enerji Sayacı', 'gomulu', 'ESP32', '#1e90ff', '#00d4ff'], ['Motor Sürücü Kartı', 'guc', 'BLDC', '#ff2e9a', '#1e90ff'], ['Veri Toplama Paneli', 'yazilim', 'WEB', '#00d4ff', '#5b2cff'], ['PLC Üretim Hattı', 'otomasyon', 'PLC', '#5b2cff', '#ff2e9a'],
['Sıcaklık Veri Kaydedici', 'gomulu', 'MCU', '#00d4ff', '#1e90ff'], ['Güç Kaynağı 1 kW', 'guc', 'SMPS', '#1e90ff', '#5b2cff'], ['Telemetri Arayüzü', 'yazilim', 'API', '#ff2e9a', '#00d4ff'], ['Sulama Otomasyonu', 'otomasyon', 'IoT', '#5b2cff', '#00d4ff']];
$('#grid').innerHTML = P.map(p => `<article class="card" data-c="${p[1]}"><div class="im" style="--c1:${p[3]};--c2:${p[4]}">${p[2]}</div><div class="in"><small>${$('#filt [data-f=' + p[1] + ']').textContent}</small><h3>${p[0]}</h3><a href="#" target="_blank" rel="noopener">Projeyi gör</a></div></article>`).join('');
$('#filt').onclick = e => {
    const b = e.target.closest('button'); if (!b) return;
    $$('#filt button').forEach(x => x.classList.toggle('on', x == b));
    $$('.card').forEach(c => c.classList.toggle('hide', b.dataset.f != 'all' && c.dataset.c != b.dataset.f))
};
/* terminal form */
$('#form').onsubmit = e => {
    e.preventDefault(); const f = e.target, o = $('#out');
    const lines = ['> bağlantı kuruluyor...', '> paket hazırlanıyor...', '> gönderildi. Teşekkürler, ' + f.n.value + '!']; o.textContent = '';
    lines.forEach((l, i) => setTimeout(() => o.textContent += (i ? '\n' : '') + l, i * 600));
    setTimeout(() => {location.href = 'mailto:ornek@eposta.com?subject=' + encodeURIComponent('Portfolyo mesajı: ' + f.n.value) + '&body=' + encodeURIComponent(f.m.value + '\n\n' + f.e.value); f.reset() }, 2000)
};
