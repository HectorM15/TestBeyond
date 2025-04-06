import React, { useState } from 'react'
import api from '../api'

function ProgressionForm({ itemId, onProgressAdded }) {
  const [percent, setPercent] = useState('')
  const [date, setDate] = useState('')

  const handleSubmit = async (e) => {
    e.preventDefault()
    try {
      await api.post(`/${itemId}/progression`, { date, percent: parseInt(percent) })
      setPercent('')
      setDate('')
      onProgressAdded()
    } catch (err) {
      alert(err.response?.data || 'Error registrando progreso')
    }
  }

  return (
    <form onSubmit={handleSubmit} className="flex gap-2 items-center mt-2">
      <input type="date" className="border p-1" value={date} onChange={e => setDate(e.target.value)} required />
      <input type="number" className="border p-1 w-16" value={percent} onChange={e => setPercent(e.target.value)} min="1" max="99" required />
      <button type="submit" className="bg-green-500 text-white px-2 py-1 rounded">Añadir progreso</button>
    </form>
  )
}

export default ProgressionForm
