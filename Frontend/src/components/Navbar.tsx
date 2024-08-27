import React from "react";
import { Link } from "react-router-dom";
import { useUser } from "../context/UserContext";

const Navbar: React.FC = () => {
  const userContext = useUser();

  if (!userContext) {
    return <div>Loading...</div>;
  }

  const { logout } = userContext;

  return (
    <div className="mx-8 min-h-16 flex justify-end gap-2 items-center">
      <Link to={"/login"}>
        <button
          onClick={logout}
          type="button"
          className="px-3 py-1.5 font-medium"
        >
          Log Out
        </button>
      </Link>
      <Link to={"/search"}>
        <button type="button" className="px-3 py-1.5 font-medium">
          Search Courses
        </button>
      </Link>
      <Link to={"/"}>
        <button type="button" className="px-3 py-1.5 font-medium">
          My Courses
        </button>
      </Link>
    </div>
  );
};

export default Navbar;
