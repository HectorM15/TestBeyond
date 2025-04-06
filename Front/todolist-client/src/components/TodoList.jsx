import React, { useEffect, useState } from 'react'
import api from '../api'
import ProgressionForm from './ProgressionForm'

function TodoList() {
  const [items, setItems] = useState([])

  const fetchData = async () => {
    const res = await api.get()
    setItems(res.data.sort((a, b) => a.id - b.id))
  }

  useEffect(() => { fetchData() }, [])

  const renderProgressionBar = (date, value) => (
    <div className="mb-2">
      <div className="text-sm text-gray-700 mb-1">{date} - {value}%</div>
      <div className="w-full bg-gray-200 rounded h-4 relative overflow-hidden">
        <div className="h-full bg-gradient-to-r from-green-400 to-blue-500 transition-all duration-500 ease-in-out"
             style={{ width: `${value}%` }}></div>
        <span className="absolute left-1/2 top-1/2 transform -translate-x-1/2 -translate-y-1/2 text-xs font-semibold text-white drop-shadow">
          {value}%
        </span>
      </div>
    </div>
  )

  const renderProgressions = (progressions) => {
    const bars = []
    let accumulated = 0
    for (let p of progressions) {
      accumulated += p.percent
      const date = new Date(p.date).toLocaleDateString()
      bars.push(renderProgressionBar(date, accumulated))
    }
    return bars
  }

  return (
    <div className="font-sans bg-white rounded shadow p-4 space-y-6">
      {items.map(item => (
        <div key={item.id}>
          <div className="font-bold text-md mb-2">
            {item.id}) {item.title} - {item.description} ({item.category}) Completed:{item.isCompleted ? 'True' : 'False'}
          </div>
          <div className="space-y-2">{renderProgressions(item.progressions)}</div>
          <ProgressionForm itemId={item.id} onProgressAdded={fetchData} />
        </div>
      ))}
    </div>
  )
}

export default TodoList
