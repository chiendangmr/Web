/* ----------------------------------------------------------------------------
 * File: mcstldef.h
 *
 * Desc: Symbian-ported STL defines
 *
 * Copyright (c) 2015 MainConcept GmbH or its affiliates.  All rights reserved.
 *
 * MainConcept and its logos are registered trademarks of MainConcept GmbH or its affiliates.  
 * This software is protected by copyright law and international treaties.  Unauthorized 
 * reproduction or distribution of any portion is prohibited by law.
 *
 * ----------------------------------------------------------------------------
 */

#if !defined (__MC_STLDEF_INCLUDED__)
#define __MC_STLDEF_INCLUDED__

#ifndef __SYMBIAN32__

#include <list>
#include <map>
#include <vector>
#include <algorithm>

#ifndef VECTOR
#define	VECTOR std::vector
#endif

#ifndef LIST
#define LIST std::list
#endif

#ifndef MAP
#define MAP std::map
#endif

#ifndef MMAP
#define MMAP std::multimap
#endif


#ifndef LOWER_BOUND
#define LOWER_BOUND std::lower_bound
#endif

#ifndef MIN
#define MIN std::min
#endif

#ifndef CONST_ITERATOR
#define CONST_ITERATOR const_iterator
#endif

#ifndef CONST
#define CONST const
#endif

#ifndef PAIR
#define PAIR std::pair
#endif

#else // __SYMBIAN32__

#include "mlist.h"
#include "smap.h"
#include "mvector.h"
//#include <algorithm>


#ifndef VECTOR  
#define VECTOR vector
#endif

#ifndef LIST
#define LIST list
#endif

#ifndef MAP
#define MAP smap
#endif

#ifndef LOWER_BOUND
#define LOWER_BOUND m_lower_bound
#endif

#ifndef MIN
#define MIN m_min
#endif

#ifndef CONST_ITERATOR
#define CONST_ITERATOR iterator
#endif

#ifndef CONST
#define CONST
#endif

#ifndef PAIR
#define PAIR pair
#endif

#endif // __SYMBIAN32__

#endif // #if !defined (__MC_STLDEF_INCLUDED__)

