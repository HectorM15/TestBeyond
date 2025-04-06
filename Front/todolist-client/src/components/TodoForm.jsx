import React, { useState } from 'react'
import api from '../api'

function TodoForm({ onAdded }) {
  const [title, setTitle] = useState('')
  const [description, setDescription] = useState('')
  const [category, setCategory] = useState('Work')

  const handleSubmit = async (e) => {
    e.preventDefault()
    try {
      await api.post('', { title, description, category })
      setTitle('')
      setDescription('')
      onAdded()
    } catch (err) {
      alert(err.response?.data || 'Error adding task')
    }
  }

  return (
    <form onSubmit={handleSubmit} className="bg-white shadow-md rounded p-4 mb-4">
      <h2 className="font-bold mb-2">Nueva tarea</h2>
      <input className="border p-1 w-full mb-2" placeholder="Título" value={title} onChange={e => setTitle(e.target.value)} required />
      <input className="border p-1 w-full mb-2" placeholder="Descripción" value={description} onChange={e => setDescription(e.target.value)} required />
      <select className="border p-1 w-full mb-2" value={category} onChange={e => setCategory(e.target.value)}>
        <option>Work</option>
        <option>Personal</option>
        <option>Urgent</option>
      </select>
      <button type="submit" className="bg-blue-500 text-white px-4 py-1 rounded">Añadir</button>
    </form>
  )
}

export default TodoForm
