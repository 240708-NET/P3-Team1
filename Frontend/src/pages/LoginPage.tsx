import react, { useState } from "react";
import axios, { AxiosError } from "axios";
import { useNavigate } from "react-router-dom";

const API_BASE = "http://localhost:5236/api";

const LoginPage: react.FC = () => {
  const [ studentID, setStudentID ] = useState("");
  const [ password, setPassword ] = useState("");
  const [ cPassword, setCPassword ] = useState("");
  const [ fName, setFName ] = useState("");
  const [ lName, setLName ] = useState("");
  const [ newUser, setNewUser ] = useState(false);
  const [ formError, setFormError ] = useState("");
  const nagivate = useNavigate();

  const login = (e: react.FormEvent) => {
    e.preventDefault();
    console.log(studentID, password);
    axios
      .post(`${API_BASE}/Student/login`, {
        id: studentID,
        firstName: "first",
        lastName: "last",
      })
      .then(() => {
        alert("Logged In");
      })
      .catch((error: AxiosError) => {
        if (error.response?.status === 401) {
          alert("Unathorized");
        } else {
          alert(error.message);
        }
      });
  };

  const registerUser = () => {
    if( !newUser ) {
      setNewUser(true);
      setFormError("");
      return;
    }
    console.log(fName, lName, password, cPassword);
    if( password == cPassword ){
      axios
        .post(`${API_BASE}/Student/register`, {
          firstName: fName,
          lastName: lName,
          password: password
        }).then(() => {
          alert(`Welcome ${fName} ${lName}!`);
        }).catch((error: AxiosError) => {
          alert(error.message);
        })
    } else {
      setFormError("Password Fields Do Not Match");
    }
  };

  const checkNewUser = () => {
    if( newUser ) {
      setNewUser(false);
      setStudentID("");
      setFormError("");
    }
  }

  return (
    <div className="flex flex-col min-h-screen justify-center px-6 py-12 bg-slate-100">
      <h2 className="text-center text-2xl font-semibold leading-9 tracking-tight text-gray-900">
        Revature University Course Registration
      </h2>

      { formError && 
        <div className="mx-auto w-full max-w-sm mt-14">
          <p className="w-full rounded-md border-0 shadow-sm ring-2 p-2 ring-rose-400 bg-red-200">{formError}</p>
        </div>
      }

      <div className="mx-auto w-full max-w-sm mt-14">
        <form onSubmit={login} className="space-y-8">
          { !newUser &&
            <input
              required
              type="text"
              id="studentID"
              name="studentID"
              value={studentID}
              placeholder="Student ID"
              className="w-full rounded-md border-0 shadow-sm ring-1 ring-inset ring-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-400 placeholder:text-gray-400"
              onChange={(e) => setStudentID(e.currentTarget.value)}
            />
          }

          { newUser &&
            <input
              required
              type="text"
              id="fName"
              name="fName"
              value={fName}
              placeholder="fName"
              className="w-full rounded-md border-0 shadow-sm ring-1 ring-inset ring-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-400 placeholder:text-gray-400"
              onChange={(e) => setFName(e.currentTarget.value)}
            />
          }

          { newUser &&
            <input
              required
              type="text"
              id="lName"
              name="lName"
              value={lName}
              placeholder="lName"
              className="w-full rounded-md border-0 shadow-sm ring-1 ring-inset ring-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-400 placeholder:text-gray-400"
              onChange={(e) => setLName(e.currentTarget.value)}
            />
          }

          <div className="mx-auto w-full max-w-sm">
            <input
              required
              type="password"
              id="password"
              name="password"
              value={password}
              placeholder="Password"
              className="w-full rounded-md border-0 shadow-sm ring-1 ring-inset ring-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-400 placeholder:text-gray-400"
              onChange={(e) => setPassword(e.currentTarget.value)}
            />
          </div>

          { newUser &&
            <div className="mx-auto w-full max-w-sm">
              <input
                type="password"
                id="cPassword"
                name="cPassword"
                value={cPassword}
                placeholder="Confirm Password"
                className="w-full rounded-md border-0 shadow-sm ring-1 ring-inset ring-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-400 placeholder:text-gray-400"
                onChange={(e) => setCPassword(e.currentTarget.value)}
              />
            </div>
          }

          <div>
            <button
              onClick={checkNewUser}
              type="submit"
              className="w-full rounded-md bg-indigo-600 px-3 py-1.5 leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600 mt-2 transition-colors duration-300"
            >
              Sign In
            </button>
          </div>

          <hr className="border-gray-300" />

          <div>
            <button
              type="button"
              value="signup"
              onClick={registerUser}
              className="w-full bg-orange-500 text-white py-2 rounded-lg hover:bg-orange-400 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600 transition-colors duration-300"
            >
              Create Account
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default LoginPage;
