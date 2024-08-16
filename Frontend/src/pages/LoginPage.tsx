import React from "react";

const LoginPage: React.FC = () => {
  const login = (e: React.ChangeEvent<HTMLFormElement>) => {
    e.preventDefault();
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
            type="text"
            id="studentID"
            name="studentID"
            placeholder="Student ID"
            required
            className="w-full rounded-md border-0 shadow-sm ring-1 ring-inset ring-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-400 placeholder:text-gray-400"
          />

          <div className="mx-auto w-full max-w-sm">
            <input
              type="text"
              id="password"
              name="password"
              placeholder="Password"
              required
              className="w-full rounded-md border-0 shadow-sm ring-1 ring-inset ring-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-400 placeholder:text-gray-400"
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
