import React from 'react'

function ProgressBar({ value }) {
  return (
    <div className="w-full bg-gray-200 rounded h-4 overflow-hidden">
      <div className="bg-blue-500 h-full" style={{ width: `${value}%` }}></div>
    </div>
  )
}

export default ProgressBar
