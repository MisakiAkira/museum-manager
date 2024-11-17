import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import './Single.css';

const Person = () => {
    const {id} = useParams();
    const [person, setPerson] = useState([]);
    const [name, setFirstName] = useState([]);
    const [surname, setLastName] = useState([]);
    const [gen, setGender] = useState([]);
    const urlPerson = 'http://localhost:5214/api/person/';
    // const apiUrl = 'http://localhost:5214/api/';
    
    useEffect(() => {
        fetch(`${urlPerson}${id}`, {method: 'GET', headers: {'Content-Type': 'application/json'}})
        .then(response => response.json())
        .then(data => setPerson(data));
    });

    const handleDelete = async () => {
        await fetch(`${urlPerson}${id}`, {method: 'DELETE', headers: {'Content-Type': 'application/json'}});
        window.location.href = "/people"
    };

    const handleUpdate = async (e) => {
        e.preventDefault();
        const id = person.id;
        let firstName = person.firstName;
        let lastName = person.lastName;
        let gender = person.gender;
        if(String(name).trim().length !== 0){
            firstName = name;
        }
        if(String(surname).trim().length !== 0){
            lastName = surname;
        }
        if(String(gen).trim().length !== 0){
            gender = gen;
        }
        const updatePerson = {
            id,
            firstName,
            lastName,
            gender
        }
        console.log(updatePerson)
        await fetch(urlPerson, {method: 'PUT', headers:{
            'Content-Type': 'application/json'
        }, body: JSON.stringify(updatePerson)});
    }

    return (
        <div class="container">
            Person ID: {person.id}<br/>
            Name: {person.firstName}<br/>
            Surname: {person.lastName}<br/>
            Gender: {person.gender}<br/><br/>
            <button class="delete-button" onClick={handleDelete}>Delete</button><br/>
            <form onSubmit={handleUpdate}>
                <label for="name">Name:</label>
                <input type="text" id='name' name='name' value={name} maxLength={50} onChange={(e) => setFirstName(e.target.value)}/><br/>
                <label for="surname">Surname:</label>
                <input type="text" id='surname' name='surname' value={surname} maxLength={50} onChange={(e) => setLastName(e.target.value)}/><br/>
                <label for="gender">Gender:</label>
                <input type="text" id="gender" name='gender' value={gen} maxLength={1} onChange={(e) => setGender(e.target.value)}/><br/>
                <button type="submit">Update</button><br/>
            </form>
        </div>
    );
};

export default Person;