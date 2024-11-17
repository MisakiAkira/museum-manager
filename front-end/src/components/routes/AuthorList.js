import React, { useState } from 'react';
import './List.css'

const Authors = () => {
    const [authors, setAuthors] = useState([]);
    const [perId, setPerId] = useState([]);
    const [desc, setDesc] = useState([]);
    const url = 'http://localhost:5214/api/';

    const getAuthors = () => {
        fetch(`${url}author`, {method: 'GET'})
        .then(response=>response.json())
        .then(data=>setAuthors(data));
    };

    const handleDeleet = async (deleteId) => {
        const response = await fetch(`${url}author/${deleteId}`, {method: 'DELETE'});
        if(response.ok){
            window.location.reload();
        }
    }

    const addAuthor = async () => {
        const id = Number(perId);
        const description = desc;
        const newAuthor = {
            id,
            description
        };
        console.log(JSON.stringify(newAuthor))
        await fetch(`${url}author`, {method: 'POST',headers:{
            'Content-Type': 'application/json'
        }, body: JSON.stringify(newAuthor)});
        setPerId('');
        setDesc('');
        window.location.reload();
    }

    return (
        <div className='container'>
            <form onSubmit={addAuthor}>
                <label for="id">Person ID:</label>
                <input type="number" id="id" name="id" value={perId} onChange={(e) => setPerId(e.target.value)} required/><br/>
                <label for="description">Description:</label>
                <input type="text" id="description" name="description" value={desc} maxLength={250} onChange={(e) => setDesc(e.target.value)} required/><br/>
                <button type='submit'>Add</button>
            </form><br/>
            <button className='button-primary' onClick={getAuthors}>Get Authors</button><br/><br/>
            <ul>
            {authors.map(author => (
                <li key={author.id}>
                    <a class="list-text" href={`author/${author.id}`}>
                        ID: {author.id}
                    </a>
                    <button class="delete-button" onClick={() => handleDeleet(author.id)}>Delete</button>
                </li>
            ))}
            </ul>
        </div>
    );
};

export default Authors;