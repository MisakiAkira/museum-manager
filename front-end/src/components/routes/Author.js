import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import './Single.css';

const Author = () => {
    const {id} = useParams();
    const [author, setPerson] = useState([]);
    const [desc, setDesc] = useState([]);
    const urlAuthor = 'http://localhost:5214/api/author/';
    
    useEffect(() => {
        fetch(`${urlAuthor}${id}`, {method: 'GET', headers: {'Content-Type': 'application/json'}})
        .then(response => response.json())
        .then(data => setPerson(data));
    });

    const handleDelete = async () => {
        await fetch(`${urlAuthor}${id}`, {method: 'DELETE', headers: {'Content-Type': 'application/json'}});
        window.location.href = "/authors"
    };

    const handleUpdate = async () => {
        const id = author.id;
        let description = author.description;
        if(String(desc).trim().length !== 0){
            description = desc;
        }
        const updateAuthor = {
            id,
            description
        }
        console.log(updateAuthor)
        await fetch(urlAuthor, {method: 'PUT', headers:{
            'Content-Type': 'application/json'
        }, body: JSON.stringify(updateAuthor)});
        setDesc('');
    }

    return (
        <div class="container">
            <a href={`../person/${author.id}`}>Author ID: {author.id}</a><br/>
            Description: {author.description}<br/><br/>
            <button class="delete-button" onClick={handleDelete}>Delete</button><br/>
            <form onSubmit={handleUpdate}>
                <label for="desc">Description:</label>
                <input type="text" value={desc} maxLength={250} onChange={(e) => setDesc(e.target.value)}/><br/>
                <button class="update-button" type="submit">Update</button><br/>
            </form>
        </div>
    );
};

export default Author;