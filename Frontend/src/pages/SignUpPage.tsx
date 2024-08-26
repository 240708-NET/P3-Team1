import { useState, FormEvent } from "react";
import { AxiosError } from "axios";
import { useNavigate } from "react-router-dom";
import { useUser } from "../context/UserContext";

export default function SignUpPage() {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [formError, setFormError] = useState("");
  const navigate = useNavigate();
  const userContext = useUser();

  if (!userContext) {
    return <div>Loading...</div>;
  }

  const { register } = userContext;

  function signup(e: FormEvent) {
    e.preventDefault();
    if (password != confirmPassword) {
      setFormError("Password fields do not match.");
    } else {
      register({
        id: -1,
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
  }

  return (
    <div className="h-screen content-center">
      <div className="mx-auto w-fit shadow-2xl rounded-2xl px-16 py-12 bg-white">
        <h2 className="text-center text-3xl font-medium leading-normal tracking-tight text-gray-900">
          Reevature Online Eniversity
        </h2>
        { formError != "" && 
          <div className="px-4 py-2 bg-red-500 text-white rounded">
            {formError}
          </div> 
        }
        <div className="px-4 py-4 mx-auto w-full max-w-sm">
          <form onSubmit={signup} className="flex flex-col gap-8">
            <div className="text-center text-2xl">Create an Account</div>
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
              required
              type="password"
              name="confirmPassword"
              value={confirmPassword}
              placeholder="Confirm Password"
              className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 text-sm leading-6"
              onChange={(e) => setConfirmPassword(e.currentTarget.value)}
            />
            <div>
              <button
                type="submit"
                className="flex w-full justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
              >
                Sign Up
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}
