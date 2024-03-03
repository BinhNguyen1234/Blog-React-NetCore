import Galaxy from "@components/Galaxy";
import SignInForm from "@components/LoginForm";
import { useState } from "react";

export default function SignIn(){
    const [fast, setFast] = useState(false)
    console.log(fast)
    return <>
    <Galaxy fast={fast}></Galaxy>
    <SignInForm setFast={setFast}></SignInForm>
    </>
}