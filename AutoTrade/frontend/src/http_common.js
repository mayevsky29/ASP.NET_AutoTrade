import axios from "axios";

export default axios.create({
  //baseURL: "http://localhost:8087/",
  baseURL: "/",
  headers: {
    "Content-type": "application/json"
  }
});