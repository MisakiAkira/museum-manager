import React, { useState } from 'react';
import './List.css'

const Restorers = () => {
    const [restorers, setRestorers] = useState([]);
    const [id, setId] = useState([]);
    const [experience, setExperience] = useState([]);
    const url = 'http://localhost:5214/api/';

    const getRestorers = () => {
        fetch(`${url}restorer`, {method: 'GET'})
        .then(response=>response.json())
        .then(data=>setRestorers(data));
    };

    const handleDeleet = async (deleteId) => {
        const response = await fetch(`${url}restorer/${deleteId}`, {method: 'DELETE'});
        if(response.ok){
            window.location.reload();
        }
    }

    const addRestorer = async () => {
        const newAuthor = {
            id,
            experience
        };
        console.log(JSON.stringify(newAuthor))
        await fetch(`${url}restorer`, {method: 'POST',headers:{
            'Content-Type': 'application/json'
        }, body: JSON.stringify(newAuthor)});
        setId('');
        setExperience('');
    }

    return (
        <div class="container">
            <form onSubmit={addRestorer}>
                <label for="id">ID:</label>
                <input type="number" id="id" name="id" value={id} onChange={(e) => setId(e.target.value)} required/><br/>
                <label for="exp">Experience:</label>
                <input type="number" id="exp" name="exp" value={experience} onChange={(e) => setExperience(e.target.value)} required/><br/>
                <button type='submit'>Add</button>
            </form><br/>
            <button class="button-primary" onClick={getRestorers}>Get Restorers</button><br/><br/>
            <ul>
            {restorers.map(restorer => (
                <li key={restorer.id}>
                    <a href={`restorer/${restorer.id}`}>
                        id: {restorer.id}
                    </a>
                    <button class="delete-button" onClick={() => handleDeleet(restorer.id)}>Delete</button>
                </li>
            ))}
            </ul>
        </div>
    );
};

export default Restorers;