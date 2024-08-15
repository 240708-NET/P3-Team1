import { useState } from 'react'
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import './App.css'
import LoginPage from './pages/LoginPage'
import StudentPage from './pages/StudentPage';
import CourseSearchPage from './pages/CourseSearchPage';



function App() {

  const router = createBrowserRouter([
    {
      path: '/',
      element: <StudentPage />
    },
    {
      path: '/search',
      element: <CourseSearchPage />
    },
    {
      path: 'login',
      element: <LoginPage />
    }
  ])

  return (
    <>
      <RouterProvider router={router} />
    </>
  )
}

export default App
