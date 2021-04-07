import axios from 'axios';

const path = '/issue';

export default {
    getIssues(collectionId) {
        return axios.get(path + '/' + collectionId)
    },

    addIssue(issue){
        return axios.post(path, issue)
    }
}