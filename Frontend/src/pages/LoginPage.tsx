import react, { useState } from "react";
import { AxiosError } from "axios";
import { Link, useNavigate } from "react-router-dom";
import { useUser } from "../context/UserContext";

export default function LoginPage() {
  const [studentID, setStudentID] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();
  const userContext = useUser();

  if (!userContext) {
    return <div>Loading...</div>;
  }

  const { login } = userContext;

  function userLogin(e: react.FormEvent) {
    e.preventDefault();
    login({
      id: parseInt(studentID),
      firstName: "first",
      lastName: "last",
      password: password,
    })
      .then(() => {
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
    <div className="h-screen content-center">
      <div className="mx-auto w-fit shadow-2xl rounded-2xl px-16 py-12 bg-white">
        <h2 className="text-center text-3xl font-medium leading-normal tracking-tight text-gray-900">
          Reevature Online Eniversity
        </h2>
        <div className="px-4 py-4 mx-auto w-full max-w-sm">
          <form onSubmit={userLogin} className="flex flex-col gap-8">
            <div className="text-center text-2xl">Course Registration</div>
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
        </div>
        <hr className="border-gray-300 my-6" />
        <div className="px-4 py-4 mx-auto w-full max-w-sm">
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
    </div>
  );
}
