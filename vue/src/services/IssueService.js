import axios from 'axios';

const path = '/issue';

export default {
    //getIssues(collectionId) {
      //  console.log(this.$store.state.collections);
       // return axios.get(path + '/' + collectionId)
   // },

    addIssue(issue, collectionId){
        console.log(issue, collectionId)
        return axios.post(path + '/' + collectionId, issue)
    }
}