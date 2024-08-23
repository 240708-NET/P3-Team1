import React from 'react';
import { Link } from 'react-router-dom';
import { useUser } from '../context/UserContext';

const Navbar: React.FC = () => {
    const userContext = useUser();

    if( !userContext ){
        return <div>Loading...</div>;
    }
    
    const { user, logout } = userContext;

    return (
        <div className="min-h-16 flex justify-end gap-4 items-center">
            <Link to={"/login"}>
                <button
                    onClick={logout}
                    type="button"
                    value="signup"
                    className="flex w-full justify-center rounded-md bg-orange-500 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-orange-400 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">
                    { user ? "Log out" : "Login" }
                </button>
            </Link>
            <Link to={"/search"}>
                <button
                    type="button"
                    value="signup"
                    className="flex w-full justify-center rounded-md bg-orange-500 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-orange-400 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">
                    Search Courses
                </button>
            </Link>
            <Link to={"/"}>
                {<button
                    type="button"
                    value="signup"
                    className="flex w-full justify-center rounded-md bg-orange-500 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-orange-400 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">
                    My Courses
                </button>}
            </Link>
        </div>
    )
}

export default Navbar;