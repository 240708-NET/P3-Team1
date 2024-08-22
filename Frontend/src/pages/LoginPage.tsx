import react, { useState } from "react";
import axios, { AxiosError } from "axios";
import { Link, useNavigate } from "react-router-dom";

const API_BASE = import.meta.env.VITE_API_BASE;

export default function LoginPage() {
  const [studentID, setStudentID] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  function login(e: react.FormEvent) {
    e.preventDefault();
    console.log(studentID, password);
    axios
      .post(`${API_BASE}/Student/login`, {
        id: studentID,
        firstName: "first",
        lastName: "last",
        password: password,
      })
      .then(() => {
        alert("Logged In");
        navigate("/");
      })
      .catch((error: AxiosError) => {
        if (error.response?.status === 401) {
          alert("Unathorized");
        } else {
          alert(error.message);
        }
      });
  }

  return (
    <div className="flex min-h-full flex-col justify-center px-6 py-12 h-screen">
      <h2 className="text-center text-3xl font-semibold leading-normal tracking-tight text-gray-900">
        Reevature Online Eniversity <br />
        Course Registration
      </h2>

      <div className="my-16 mx-auto w-full max-w-sm">
        <form onSubmit={login} className="space-y-8">
          <input
            required
            type="text"
            name="studentID"
            value={studentID}
            placeholder="Student ID"
            className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 text-sm leading-6"
            onChange={(e) => setStudentID(e.currentTarget.value)}
          />

          <input
            required
            type="password"
            name="password"
            value={password}
            placeholder="Password"
            className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 text-sm leading-6"
            onChange={(e) => setPassword(e.currentTarget.value)}
          />

          <div>
            <button
              type="submit"
              className="flex w-full justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
            >
              Sign In
            </button>
          </div>
        </form>

        <hr className="border-gray-300 my-8" />

        <Link to={"/signup"}>
          <button
            type="button"
            value="signup"
            className="flex w-full justify-center rounded-md bg-orange-500 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-orange-400 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
          >
            Create Account
          </button>
        </Link>
      </div>
    </div>
  );
}
