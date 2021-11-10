import {LOAD_USERS} from "../constants/actionTypes";
import userService from "../services/user.service";


export const LoadUser = () => async(dispatch) => {

    try {
        const result = await userService.getdata(); 
        console.log("All users:", result.data);        
        dispatch({type: LOAD_USERS, data: result.data});    
    }
    catch(error) {
        console.log("Сталася помилка",error);
    }
}