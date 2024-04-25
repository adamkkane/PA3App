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
    let html = '';
    myData.forEach(function (data) {
        let pin = data.pinned ? "✅" : "❌";
        html += `
        <tr>
            <td>${data.movieName}</td>
            <td>${data.movieRating}</td>
            <td>${data.movieReleaseDate}</td>
            <td><button onclick="handleDataDelete(${data.movieID})" class="btn btn-danger">Delete</button></td>
            <td><button onclick="handleDataPin(${data.movieID})">${pin}</button></td>
        </tr>`;
    });
    document.querySelector('.table').innerHTML = `
        <tr>
            <th>Movie Name</th>
            <th>Movie Rating</th>
            <th>Date Released (MM/DD/YYYY)</th>
            <th>Delete</th>
            <th>Pin</th>
        </tr>
        ${html}`;
}

function handleDataDelete(id) {
    fetch(`http://localhost:5050/api/Movies/${id}`, {
        method: 'DELETE'
    })
    .then(() => {
        myData = myData.filter(data => data.movieID != id);
        populateTable();
    })
}

function handleDataPin(id) {
    for (let i = 0; i < myData.length; i++) {
        if (myData[i].movieID == id) {
            myData[i].pinned = !myData[i].pinned;
            break;
        }
    }
    populateTable();
}

function handleAddMovie() {
    const movieName = document.getElementById('movieName').value;
    const movieRating = document.getElementById('movieRating').value;
    const movieReleaseDate = document.getElementById('movieReleaseDate').value;

    const newMovie = {
        movieName: movieName,
        movieRating: movieRating,
        movieReleaseDate: movieReleaseDate
    };

    fetch('http://localhost:5050/api/Movies/AddMovie', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newMovie)
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('Failed to add movie');
        }
        return response.json();
    })
    .then(data => {
        myData.push(data);
        populateTable();
    })
    .catch(error => console.error('Error adding movie:', error));
}

document.getElementById("addMovieForm").addEventListener("submit", function(event) {
    event.preventDefault(); // Prevent default form submission
    handleAddMovie();
});
