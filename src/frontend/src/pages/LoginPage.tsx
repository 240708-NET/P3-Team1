import React from 'react';

const LoginPage: React.FC = () => {

    const login = (e: React.ChangeEvent<HTMLFormElement>) => {
        e.preventDefault();
        
    }

    const registerUser = () => {
        
    }
    
    return (
        <div className="min-h-screen flex items-center justify-center bg-blue-50">
            <form onSubmit={login}>
                <div>
                    <label htmlFor="studentID"> Student ID: </label>
                    <input type="text" id="studentID" name="studentID" required/>
                </div>
                
                <div>
                    <label htmlFor="studentID"> Password: </label>
                    <input type="password" id="password" name="password" required/>
                </div>
                
                <div>
                    <button type="submit" className="w-full bg-orange-500 text-white py-2 rounded-lg hover:bg-orange-600 transition-colors duration-300" value="login">Login</button>
                </div>

                <div>
                    <button type="button" value="signup" onClick={registerUser}>Register</button>
                </div>
            </form>
        </div>
    )
}

export default LoginPage;
