import React, {
  createContext,
  forwardRef,
  HTMLAttributes,
  useEffect,
  useState,
} from 'react'
import PropTypes from 'prop-types'
import API from '../../API'
import { useFetch } from '../Utils/useFetch'

const AuthContext = createContext({})

export type AuthContextProps = HTMLAttributes<HTMLDivElement>

export const AuthContextProvider = forwardRef<HTMLDivElement, AuthContextProps>(
  ({ children }, ref) => {
    const [userResponse, loginApiCall] = useFetch(API.login.APIurl, 'POST')
    const [user, setUser] = useState(() => {
      const currentUserStored = localStorage.getItem('currentUser')
      if (currentUserStored) {
        return JSON.parse(currentUserStored)
      }
      return null
    }) as any

    useEffect(() => {
      loadUser(userResponse)
    }, [userResponse])

    const loadUser = (createdUser: any) => {
      //TODO: cambiar este loadUser X funcion loginApiCall multi parametros
      if (!createdUser?.name) return
      setUser(createdUser)
      localStorage.setItem('currentUser', JSON.stringify(createdUser))
    }

    return (
      <AuthContext.Provider value={{ loginApiCall, user, loadUser }}>
        {children}
      </AuthContext.Provider>
    )
  },
)
AuthContextProvider.propTypes = {
  children: PropTypes.node.isRequired,
}

AuthContextProvider.displayName = 'AuthContextProvider'

export default AuthContext
