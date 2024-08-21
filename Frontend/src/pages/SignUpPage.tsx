import { useState, FormEvent } from "react";
import axios, { AxiosError } from "axios";
import { useNavigate } from "react-router-dom";

const API_BASE = import.meta.env.VITE_API_BASE;

export default function SignUpPage() {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [formError, setFormError] = useState("");
  const navigate = useNavigate();

  function signup(e: FormEvent) {
    e.preventDefault();
    if (password != confirmPassword) {
      setFormError("Password fields do not match.");
    }
    axios
      .post(`${API_BASE}/Student/register`, {
        id: "",
        firstName: firstName,
        lastName: lastName,
        password: password,
      })
      .then(() => {
        alert(`Welcome ${firstName} ${lastName}!`);
        navigate("/");
      })
      .catch((error: AxiosError) => {
        alert(error.message);
      });
  }

  return (
    <div className="flex min-h-full flex-col justify-center px-6 py-12 h-screen">
      <h2 className="text-center text-3xl font-semibold leading-normal tracking-tight text-gray-900">
        Reevature Online Eniversity <br />
        Course Registration
      </h2>

      <div className="my-16 mx-auto w-full max-w-sm">
        <form onSubmit={signup} className="space-y-8">
          {formError && (
            <div className="mx-auto w-full max-w-sm">
              <p className="w-full rounded-md border-0 shadow-sm ring-2 px-3 py-2 ring-rose-400 bg-red-200">
                {formError}
              </p>
            </div>
          )}

          <input
            required
            type="text"
            name="firstName"
            value={firstName}
            placeholder="First Name"
            className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 text-sm leading-6"
            onChange={(e) => setFirstName(e.currentTarget.value)}
          />

          <input
            required
            type="text"
            name="lastName"
            value={lastName}
            placeholder="Last Name"
            className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 text-sm leading-6"
            onChange={(e) => setLastName(e.currentTarget.value)}
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

          <input
            type="password"
            name="confirmPassword"
            value={confirmPassword}
            placeholder="Confirm Password"
            className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 text-sm leading-6"
            onChange={(e) => setConfirmPassword(e.currentTarget.value)}
          />

          <button
            type="submit"
            className="flex w-full justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
          >
            Sign Up
          </button>
        </form>
      </div>
    </div>
  );
}
