import {LOAD_USERS } from "../constants/actionTypes";

const initialState ={
   list:[]
}

// function usersReducer(state = initialState, action)
// {
//     const{ type, data }=action;
//     console.log("Reducer user data :", data);

//     switch(type)
//     {
//         case LOAD_USERS: {
//             return {               
//                list:data
//             }            
//         }
//         default:
//             return state;
//     }
// }

const usersReducer = (state = initialState, action) => {
    const {type, payload} = action;
    console.log("Reducer user data :", payload);
    switch(type) {
        case LOAD_USERS: {
            return {
                ...state,
                list: payload
            };
        } 
        default: {
            return state;
        }
    }


}

export default usersReducer;

