import {LOAD_USERS} from "../constants/actionTypes";
import userService from "../services/user.service";


export const LoadUser = () => async(dispatch) => {

    try {
        const {data} = await userService.getdata(); 
        console.log("All users:", data);        
        dispatch({type: LOAD_USERS, payload: data});    
    }
    catch(error) {
        console.log("Сталася помилка",error);
    }
}