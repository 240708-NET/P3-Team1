import { createBrowserRouter, RouterProvider } from "react-router-dom";
import LoginPage from "./pages/LoginPage";
import StudentPage from "./pages/StudentPage";
import CourseSearchPage from "./pages/CourseSearchPage";
import MyCoursesPage from "./pages/MyCoursesPage";
import SignUpPage from "./pages/SignUpPage";
import UserProvider from "./context/UserContext";
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
    {
      path: "signup",
      element: <SignUpPage />,
    },
    {
      path: "mycourses",
      element: <MyCoursesPage />,
    },
  ]);

  return (
    <UserProvider>
      <RouterProvider router={router} />
    </UserProvider> 
  );
}

export default App;
