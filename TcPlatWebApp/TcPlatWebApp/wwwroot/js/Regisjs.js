function showSuccessDialog(message) {
    alert(message); // Replace this with any custom dialog logic
}

function showLoadingModal(username) {
    // Update the welcome message
    document.querySelector("#loadingModal .loading-message").textContent = `Benvenuto, ${username}`;
    // Show the loading modal
    document.getElementById('loadingModal').style.display = 'flex';
}

function hideLoadingModal() {
    // Hide the loading modal
    document.getElementById('loadingModal').style.display = 'none';
}