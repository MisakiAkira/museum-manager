import React, { useState } from 'react';
import './List.css';

const Paintings = () => {
    const [paintings, setPaintings] = useState([]);
    const [auId, setAuthordId] = useState([]);
    const [pName, setName] = useState([]);
    const [pDate, setDate] = useState([]);
    const [desc, setDesc] = useState([]);
    const urlPainting = 'http://localhost:5214/api/painting/';
    
    const getPaintings = () => {
        fetch(urlPainting, {method: 'GET', headers: {'Content-Type': 'application/json'}})
        .then(response => response.json())
        .then(data => setPaintings(data));
    };

    const handleDelete = async (deleteId) => {
        const response = await fetch(urlPainting + deleteId, {method: 'DELETE'});
        if(response.ok){
            window.location.reload();
        }
    }

    const addPainting = async () => {
        const id = 0;  
        const newPerson = {
            id,
            "authorId": auId,
            "name": pName,
            "paintingDate": pDate,
            "description": desc
        };
        console.log(JSON.stringify(newPerson))
        await fetch(urlPainting, {method: 'POST',headers:{
            'Content-Type': 'application/json'
        }, body: JSON.stringify(newPerson)});
        setAuthordId('');
        setName('');
        setDate('');
        setDesc('');
    }

    return (
        <div className='container'>
            <form onSubmit={addPainting}>
                <label for="id">Author ID:</label>
                <input type="number" id="id" name="id" value={auId} onChange={(e) => setAuthordId(e.target.value)} required/><br/>
                <label for="name">Name:</label>
                <input type="text" id="name" name="name" value={pName} maxLength={50} onChange={(e) => setName(e.target.value)} required/><br/>
                <label for="date">Painting date:</label>
                <input type="date" id="date" name="name" value={pDate} onChange={(e) => setDate(e.target.value)} required/><br/>
                <label fro="desc">Description:</label>
                <input type="text" id="desc" name="desc" value={desc} maxLength={255} onChange={(e) => setDesc(e.target.value)} required/><br/>
                <button type="submit">Add</button><br/>
            </form><br/>
            <button class="button-primary" onClick={getPaintings}>Get all people</button><br/><br/>
            <ul>
            {paintings.map(painting => (
                <li key={painting.id}>
                    <a class="list-text" href={`painting/${painting.id}`}>
                        ID: {painting.id}
                    </a> 
                    <button class="delete-button" onClick={() => handleDelete(painting.id)}>Delete</button>
                </li>
            ))}
            </ul>
        </div>
    );
};

export default Paintings;