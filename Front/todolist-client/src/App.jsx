import React from 'react'
import TodoForm from './components/TodoForm'
import TodoList from './components/TodoList'

function App() {
  return (
    <div className="container mx-auto p-4">
      <h1 className="text-2xl font-bold mb-4">TodoList App</h1>
      <TodoForm onAdded={() => window.location.reload()} />
      <TodoList />
    </div>
  )
}

export default App
