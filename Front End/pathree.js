let myData = [];

function handleOnLoad() {
    fetch('http://localhost:5050/api/Movies/Movies')
        .then(response => {
            if (!response.ok) {
                throw new Error('Failed');
            }
            return response.json();
        })
        .then(dataList => {
            myData = dataList;
            console.log('Fetched data:', myData);
            populateTable();
        })
        .catch(error => console.error('Error fetching data:', error));
}

function populateTable() {
    let html = `
    <h2>Movie List</h2>
    <table class="table table-striped">
        <tr>
            <th>Movie Name</th>
            <th>Movie Rating</th>
            <th>Date Released (MM/DD/YYYY)</th>
            <th>Delete</th>
            <th>Pin</th>
        </tr>
        `;
    myData.forEach(function (data) {
        let pin = data.pinned ? "✅" : "❌";
        html += `
        <tr>
            <td>${data.MovieName}</td>
            <td>${data.MovieRating}</td>
            <td>${data.MovieReleaseDate}</td>
            <td><button onclick="handleDataDelete('${data.MovieID}')" class="btn btn-danger">Delete</button></td>
            <td><button onclick="handleDataPin('${data.MovieID}')">${pin}</button></td>
        </tr>`;
    });
    html += `</table>`;
    document.getElementById('app').innerHTML = html;
}

function handleDataDelete(id) {
    fetch(`http://localhost:5050/api/Movies/${id}`, {
        method: 'DELETE'
    })
    .then(() => {
        myData = myData.filter(data => data.MovieID != id);
        populateTable();
    })
    .catch(error => console.error('Error deleting data:', error));
}

function handleDataPin(id) {
    for (let i = 0; i < myData.length; i++) {
        if (myData[i].MovieID == id) {
            myData[i].pinned = !myData[i].pinned;
            break;
        }
    }
    populateTable();
}
