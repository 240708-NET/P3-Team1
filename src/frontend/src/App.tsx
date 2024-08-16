import { createBrowserRouter, RouterProvider } from "react-router-dom";
import LoginPage from "./pages/LoginPage";
import StudentPage from "./pages/StudentPage";
import CourseSearchPage from "./pages/CourseSearchPage";

import "./App.css";

function App() {
  const router = createBrowserRouter([
    {
      path: "/",
      element: <StudentPage />,
    },
    {
      path: "search",
      element: <CourseSearchPage />,
    },
    {
      path: "login",
      element: <LoginPage />,
    },
  ]);

  return <RouterProvider router={router} />;
}

export default App;
