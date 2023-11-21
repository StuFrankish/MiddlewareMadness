// Get a reference to the div with id "jscontent"
const jscontent = document.getElementById('jscontent');

// Replace 'your-api-endpoint' with the actual API endpoint URL
const apiUrl = '/api/info';

// Make a GET request to the API endpoint
fetch(apiUrl)
    .then(response => {
        // Check if the request was successful (status code 200)
        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }
        // Parse the JSON response
        return response.json();
    })
    .then(data => {
        // Update the content of the div with the JSON data
        jscontent.textContent = JSON.stringify(data, null, 2);
    })
    .catch(error => {
        console.error('Fetch error:', error);
        jscontent.textContent = 'Error fetching data from the API.';
    });