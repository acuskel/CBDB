import axios from 'axios';

const path = '/issue';

export default {
    

    addIssue(issue){
        return axios.post(path, issue)
    }
}