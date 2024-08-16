import react from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";

const API_BASE = "https://localhost:8000/api";

const LoginPage: react.FC = () => {
  const [studentID, setStudentID] = react.useState("");
  const [password, setPassword] = react.useState("");
  const nagivate = useNavigate();

  const login = (e: react.FormEvent) => {
    e.preventDefault();
    console.log(studentID, password);
    axios
      .post(`${API_BASE}/login`, {
        studentID: studentID,
        password: password,
      })
      .finally(() => nagivate("/"));
  };

  const registerUser = () => {};

  return (
    <div className="flex flex-col min-h-screen justify-center px-6 py-12 bg-slate-100">
      <h2 className="text-center text-2xl font-semibold leading-9 tracking-tight text-gray-900">
        Revature University Course Registration
      </h2>

      <div className="mx-auto w-full max-w-sm mt-14">
        <form onSubmit={login} className="space-y-8">
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

          <div>
            <button
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
