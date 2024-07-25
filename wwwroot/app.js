function openInNewTab(url) {
    window.open(url, '_blank');
}

function previewImage(inputFileElement, imgElement) {

    let input = document.getElementById(inputFileElement)
    let image = document.getElementById(imgElement)

    const file = input.files[0];

    if (file) {
        const reader = new FileReader();
        reader.onload = (e) => {
            image.src = e.target.result;
        };
        reader.readAsDataURL(file);
    }
}
function resetPreviewImage(inputFileElement, imgElement) {
    let input = document.getElementById(inputFileElement)
    let image = document.getElementById(imgElement)

    input.value = '';
    image.src = '/images/profile/avatar.png';
}
function scrollToBottom(element) {
    const container = document.querySelector(element);
    container.scrollTop = container.scrollHeight;
}
