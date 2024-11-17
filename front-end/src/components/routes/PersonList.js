import React, { useState } from 'react';
import './List.css';

const People = () => {
    const [people, setPeople] = useState([]);
    const [firstName, setFirstName] = useState([]);
    const [lastName, setLastName] = useState([]);
    const [gender, setGender] = useState([]);
    const urlPerson = 'http://localhost:5214/api/person/';
    
    const getPeople = () => {
        fetch(urlPerson, {method: 'GET', headers: {'Content-Type': 'application/json'}})
        .then(response => response.json())
        .then(data => setPeople(data));
    };

    const handleDelete = async (deleteId) => {
        const response = await fetch(urlPerson + deleteId, {method: 'DELETE'});
        if(response.ok){
            window.location.reload();
        }
    }

    const addPerson = async () => {
        const id = 0;  
        const newPerson = {
            id,
            firstName,
            lastName,
            gender
        };
        console.log(JSON.stringify(newPerson))
        await fetch(urlPerson, {method: 'POST',headers:{
            'Content-Type': 'application/json'
        }, body: JSON.stringify(newPerson)}).then(response => console.log(response));
        setFirstName('');
        setLastName('');
        setGender('');
    }

    return (
        <div class="container">
            <form onSubmit={addPerson}>
                <label for="name">First name:</label>
                <input type="text" id="name" name="name" value={firstName} maxLength={50} onChange={(e) => setFirstName(e.target.value)} required/><br/>
                <label for="surname">Last name:</label>
                <input type="text" id="surname" name="surname" value={lastName} maxLength={50} onChange={(e) => setLastName(e.target.value)} required/><br/>
                <label for="gender">Gender:</label>
                <input type="text" id="gender" name="gender" value={gender} maxLength={1} onChange={(e) => setGender(e.target.value)} required/><br/>
                <button type="submit">Add</button><br/>
            </form><br/>
            <button class="button-primary" onClick={getPeople}>Get all people</button><br/><br/>
            {people.map(person => (
                <li key={person.id}>
                    <a href={`person/${person.id}`}>
                        ID: {person.id}
                    </a> 
                    <button class="delete-button" onClick={() => handleDelete(person.id)}>Delete</button>
                </li>
            ))}
        </div>
    );
};

export default People;